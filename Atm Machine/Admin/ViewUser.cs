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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Atm_Machine
{
    public partial class ViewUser : Form
    {
        public ViewUser()
        {
            InitializeComponent();
            ShowAllUsers();
        }

        private void BackClick(object sender, EventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();
            this.Close();
            adminPanel.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowSpecificUser();
        }


        private void ShowAllUsers()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Atm;Integrated Security=True;" +
               "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            string query = "SELECT Id, Password, Amount, Name, Email, isCardActivated " +
                            "FROM Users ";

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

        private void ShowSpecificUser()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Atm;Integrated Security=True;" +
                "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            string userId = textBox1.Text;

            if (string.IsNullOrWhiteSpace(userId))
            {
                DialogResult result = MessageBox.Show(" Please enter a valid UserId or click the OK button to show all the users.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    ShowAllUsers();
                }
                return;
            }

            string query = "SELECT Id, Password, Amount, Name, Email, isCardActivated " +
                           "FROM Users " +
                           "WHERE Id = @userId";

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

        
    }
}
