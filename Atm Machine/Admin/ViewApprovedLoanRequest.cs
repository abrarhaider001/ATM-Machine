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
    public partial class ViewApprovedLoanRequest : Form
    {
        public ViewApprovedLoanRequest()
        {
            InitializeComponent();
            showApproveLoanRequests();
        }

        private void showApproveLoanRequests()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Atm;Integrated Security=True;" +
               "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            string query = @"SELECT RequestId, UserId, LoanAmount, ApprovedDate FROM ApprovedLoanRequests ";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, con);

                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    Cursor = Cursors.Default;
                    con.Close();
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            showApproveLoanRequests();
        }
    }
}
