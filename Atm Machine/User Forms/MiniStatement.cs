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

namespace Atm_Machine
{
    public partial class MiniStatement : Form
    {
        private UserClass currentUser;
        public MiniStatement(UserClass currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            ShowTransactionHistory();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProcceedTransaction procceedTransaction = new ProcceedTransaction(currentUser);
            this.Close();
            procceedTransaction.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowFilteredTransactionHistory();
        }

        private void ShowTransactionHistory()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Atm;Integrated Security=True;" +
                "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            int userId = currentUser.Id;
            string query = "SELECT TransactionId, UserId, TransactionDate, Amount, TransactionType FROM Transactions WHERE UserId = @userId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId);

                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);

                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void ShowFilteredTransactionHistory()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Atm;Integrated Security=True;" +
                "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            string amountText = textBox1.Text;
            decimal amount;

            if (string.IsNullOrWhiteSpace(amountText))
            {
                DialogResult result = MessageBox.Show(" Please enter a valid amount or click the OK button to show all transactions.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                if (result == DialogResult.OK)
                {
                    ShowTransactionHistory();
                }
                return;
            }

            if (!decimal.TryParse(amountText, out amount))
            {
                MessageBox.Show("Please enter a valid numeric amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "SELECT TransactionId, UserId, TransactionDate, Amount, TransactionType " +
                           "FROM Transactions " +
                           "WHERE UserId = @userId AND Amount <= @amount";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", currentUser.Id);
                        command.Parameters.AddWithValue("@amount", amount);

                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);

                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                int id = Convert.ToInt32(row.Cells["TransactionId"].Value);
                string userId = row.Cells["UserId"].Value.ToString();
                DateTime dateTime = Convert.ToDateTime(row.Cells["TransactionDate"].Value);
                int amount = Convert.ToInt32(row.Cells["Amount"].Value);
                string type = row.Cells["TransactionType"].Value.ToString();

                TransactionClass transaction = new TransactionClass(id, userId, dateTime, amount, type);

                TransactionDetail detailForm = new TransactionDetail(transaction);
                detailForm.ShowDialog();
            }
        }

    }
}
