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
    public partial class BalanceInquiry : Form
    {
        private UserClass currentUser;
        bool isBalanceShowed = false;
        bool isLabelText = false;
        public BalanceInquiry(UserClass user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void ShowClick(object sender, EventArgs e)
        {
            if (!isBalanceShowed)
            {
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Atm;Integrated Security=True;" +
                            "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    try
                    {
                        con.Open();

                        int id = currentUser.Id;

                        string query = "SELECT Amount FROM Users WHERE Id = @Id";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@Id", id);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int currentBalance = reader.GetInt32(0);
                                    string balanceToShow = currentBalance.ToString();
                                    label4.Text = balanceToShow;
                                    label1.Text = "Hide";
                                    isBalanceShowed = true;
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
                }
            }
            else
            {
                label4.Text = "******";
                label1.Text = "Show";
                isBalanceShowed = false;
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
