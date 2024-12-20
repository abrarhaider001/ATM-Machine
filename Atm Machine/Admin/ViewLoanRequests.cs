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

namespace Atm_Machine.Admin
{
    public partial class ViewLoanRequests : Form
    {
        public ViewLoanRequests()
        {
            InitializeComponent();
            showAllLoanRequests();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminPanel admin = new AdminPanel();
            this.Hide();
            admin.Show();
        }

        private void showAllLoanRequests()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Atm;Integrated Security=True;" +
               "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            string query = "SELECT RequestId, UserId, LoanAmount, RequestDate, Status " +
                           "FROM LoanRequests ";

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                int requestId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["RequestId"].Value);
                string userId = dataGridView1.Rows[e.RowIndex].Cells["UserId"].Value.ToString();
                int intUserId = int.Parse(userId);
                decimal loanAmount = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["LoanAmount"].Value);
                string requestDate = dataGridView1.Rows[e.RowIndex].Cells["RequestDate"].Value.ToString();
                string status = dataGridView1.Rows[e.RowIndex].Cells["Status"].Value.ToString();

                LoanRequestClass loan = new LoanRequestClass(requestId, intUserId, loanAmount, requestDate, status);

                ApproveLoan approve = new ApproveLoan(loan);
                approve.ShowDialog();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ViewApprovedLoanRequest viewApproveLoan = new ViewApprovedLoanRequest();
            viewApproveLoan.ShowDialog();
            Cursor = Cursors.Default;
        }
    }
}
