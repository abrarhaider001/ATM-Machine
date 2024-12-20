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
using System.Transactions;
using System.Windows.Forms;

namespace Atm_Machine.Admin
{
    public partial class ApproveLoan : Form
    {
        LoanRequestClass loanRequest;

        public ApproveLoan(LoanRequestClass loan)
        {
            InitializeComponent();
            loanRequest = loan;
            PopulateDetailsInGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int requestId = loanRequest.RequestId;
            int userId = loanRequest.UserId;
            decimal loanAmount = loanRequest.LoanAmount;

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Atm;Integrated Security=True;" +
               "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {
                            string addTransactionQuery = @"INSERT INTO Transactions (UserId, Amount, TransactionType) 
                                                            VALUES (@UserId, @Amount, 'Loan Approved')";
                            using (SqlCommand cmd = new SqlCommand(addTransactionQuery, con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@UserId", userId);
                                cmd.Parameters.AddWithValue("@Amount", loanAmount);
                                cmd.ExecuteNonQuery();
                            }

                            string updateUserAmountQuery = @"UPDATE Users 
                                                            SET Amount = Amount + @LoanAmount 
                                                            WHERE Id = @UserId";

                            using (SqlCommand cmd = new SqlCommand(updateUserAmountQuery, con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@LoanAmount", loanAmount);
                                cmd.Parameters.AddWithValue("@UserId", userId);
                                cmd.ExecuteNonQuery();
                            }

                            string deleteLoanRequestQuery = @"DELETE FROM LoanRequests 
                                                            WHERE RequestId = @RequestId";

                            using (SqlCommand cmd = new SqlCommand(deleteLoanRequestQuery, con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@RequestId", requestId);
                                cmd.ExecuteNonQuery();
                            }

                            string insertApprovedLoanQuery = @"INSERT INTO ApprovedLoanRequests (UserId, LoanAmount, RequestId)
                                                                VALUES (@UserId, @LoanAmount, @RequestId)";
                            using (SqlCommand cmd = new SqlCommand(insertApprovedLoanQuery, con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@UserId", userId);
                                cmd.Parameters.AddWithValue("@LoanAmount", loanAmount);
                                cmd.Parameters.AddWithValue("@RequestId", requestId);
                                cmd.ExecuteNonQuery();
                            }

                            string updateLoanStatusQuery = @"UPDATE LoanRequests 
                                                            SET Status = 'Approved' 
                                                            WHERE RequestId = @RequestId";

                            using (SqlCommand cmd = new SqlCommand(updateLoanStatusQuery, con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@RequestId", requestId);
                                cmd.ExecuteNonQuery();
                            }

                            // Commit transaction
                            transaction.Commit();
                            MessageBox.Show("Loan approved successfully!","Loan Approved",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error: " + ex.Message);
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message);
            }


        }
        //private void ApproveButton_Click(object sender, EventArgs e)
        //{
        //    // Example: Replace this with the actual RequestId and UserId values from the selected loan request
        //    int requestId = loanRequest.RequestId; // Loan Request ID
        //    int userId = loanRequest.UserId; // User ID
        //    decimal loanAmount = loanRequest.LoanAmount; // Loan Amount

        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();

        //            // Start a transaction for atomicity
        //            using (SqlTransaction transaction = connection.BeginTransaction())
        //            {
        //                try
        //                {
        //                    // 1. Add to transaction history
        //                    string addTransactionQuery = @"
        //                        INSERT INTO Transactions (UserId, Amount, TransactionType) 
        //                        VALUES (@UserId, @Amount, 'Loan Approved')";
        //                    using (SqlCommand cmd = new SqlCommand(addTransactionQuery, connection, transaction))
        //                    {
        //                        cmd.Parameters.AddWithValue("@UserId", userId);
        //                        cmd.Parameters.AddWithValue("@Amount", loanAmount);
        //                        cmd.ExecuteNonQuery();
        //                    }

        //                    // 2. Add amount to user's account
        //                    string updateUserAmountQuery = @"
        //                        UPDATE Users 
        //                        SET Amount = Amount + @LoanAmount 
        //                        WHERE Id = @UserId";
        //                    using (SqlCommand cmd = new SqlCommand(updateUserAmountQuery, connection, transaction))
        //                    {
        //                        cmd.Parameters.AddWithValue("@LoanAmount", loanAmount);
        //                        cmd.Parameters.AddWithValue("@UserId", userId);
        //                        cmd.ExecuteNonQuery();
        //                    }

        //                    // 3. Delete loan request
        //                    string deleteLoanRequestQuery = @"
        //                        DELETE FROM LoanRequests 
        //                        WHERE RequestId = @RequestId";
        //                    using (SqlCommand cmd = new SqlCommand(deleteLoanRequestQuery, connection, transaction))
        //                    {
        //                        cmd.Parameters.AddWithValue("@RequestId", requestId);
        //                        cmd.ExecuteNonQuery();
        //                    }

        //                    // 4. Update status to "Approved"
        //                    string updateLoanStatusQuery = @"
        //                        UPDATE LoanRequests 
        //                        SET Status = 'Approved' 
        //                        WHERE RequestId = @RequestId";
        //                    using (SqlCommand cmd = new SqlCommand(updateLoanStatusQuery, connection, transaction))
        //                    {
        //                        cmd.Parameters.AddWithValue("@RequestId", requestId);
        //                        cmd.ExecuteNonQuery();
        //                    }

        //                    // Commit transaction
        //                    transaction.Commit();
        //                    MessageBox.Show("Loan approved successfully!");
        //                }
        //                catch (Exception ex)
        //                {
        //                    // Rollback transaction in case of an error
        //                    transaction.Rollback();
        //                    MessageBox.Show("Error: " + ex.Message);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Database connection error: " + ex.Message);
        //    }
        //}

        private void PopulateDetailsInGrid()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("Field", "Field");
            dataGridView1.Columns.Add("Value", "Value");

            dataGridView1.Rows.Add("RequestId", loanRequest.RequestId);
            dataGridView1.Rows.Add("UserId", loanRequest.UserId);
            dataGridView1.Rows.Add("Date", loanRequest.RequestDate);
            dataGridView1.Rows.Add("Amount", loanRequest.LoanAmount);
            dataGridView1.Rows.Add("Status", loanRequest.Status);

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
        }

    }
}
