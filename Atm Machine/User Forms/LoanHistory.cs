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

namespace Atm_Machine.User_Forms
{
    public partial class LoanHistory : Form
    {
        private UserClass currentUser;
        public LoanHistory(UserClass user)
        {
            InitializeComponent();
            this.currentUser = user;
            showAllLoanRequests();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showAllLoanRequests()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Atm;Integrated Security=True;" +
               "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            string query = "SELECT LoanAmount, RequestDate, Status " +
                           "FROM LoanRequests " +
                           "WHERE userId = @userId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", currentUser.Id);

                    try
                    {
                        connection.Open();
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

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
        }

    }
}
