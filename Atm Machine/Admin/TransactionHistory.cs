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
    public partial class TransactionHistory : Form
    {
        public TransactionHistory()
        {
            InitializeComponent();
            ShowAllData();
        }

        private void BackClick(object sender, EventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();
            this.Close();
            adminPanel.Show();
        }

        private void ShowAllData()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Atm;Integrated Security=True;" +
               "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            string query = "SELECT TransactionId, UserId, TransactionDate, Amount, TransactionType FROM Transactions";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void ShowFilteredData()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Atm;Integrated Security=True;" +
               "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            string transactionId = textBox1.Text;

            if (string.IsNullOrWhiteSpace(transactionId))
            {
                MessageBox.Show("Please enter a valid UserId.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            string query = "SELECT TransactionId, UserId, TransactionDate, Amount, TransactionType FROM Transactions WHERE TransactionId = @transactionId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    dataAdapter.SelectCommand.Parameters.AddWithValue("@transactionId", transactionId);

                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }



        private void ShowDataClick(object sender, EventArgs e)
        {
            ShowFilteredData();
        }

    }
}
