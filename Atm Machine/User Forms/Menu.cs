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
    public partial class Menu : Form
    {
        private UserClass currentUser;
        public Menu(UserClass user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void ActivateCardClick(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Atm;Integrated Security=True;" +
                "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    int id = currentUser.Id;

                    string query = "SELECT isCardActivated FROM Users WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    
                    cmd.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        bool isCardActivated = reader.GetBoolean(0);

                        if (!isCardActivated)
                        {
                            reader.Close();

                            string updateQuery = "UPDATE Users SET isCardActivated = 1 WHERE Id = @Id";
                            SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                            updateCmd.Parameters.AddWithValue("@Id", id);
                            updateCmd.ExecuteNonQuery();

                            MessageBox.Show("Your card is activated right now.", "Card Activation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            isCardActivated = true;
                        }
                        else
                        {

                            MessageBox.Show("Your card is already activated.", "Card Activation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        string password = currentUser.Password;
                        string name = currentUser.Name;
                        string email = currentUser.Email;

                        currentUser = new UserClass(id, password, name, email, isCardActivated);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ProcceedTransactionClick(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Atm;Integrated Security=True;" +
                "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    int id = currentUser.Id;

                    string query = "SELECT isCardActivated FROM Users WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        bool isCardActivated = reader.GetBoolean(0);

                        if (!isCardActivated)
                        {
                            reader.Close();

                            MessageBox.Show("Your card is not activated make sure that your card is activated.", "Card Activation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            ProcceedTransaction pt = new ProcceedTransaction(currentUser);
                            this.Close();
                            pt.Show();

                        }

                        string password = currentUser.Password;
                        string name = currentUser.Name;
                        string email = currentUser.Email;

                        currentUser = new UserClass(id, password, name, email, isCardActivated);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



        }

        private void ProcceedTransactionClick1(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Atm;Integrated Security=True;" +
                "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    int id = currentUser.Id;

                    string query = "SELECT isCardActivated FROM Users WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        bool isCardActivated = reader.GetBoolean(0);

                        if (!isCardActivated)
                        {
                            reader.Close();

                            MessageBox.Show("Your card is not activated make sure that your card is activated.", "Card Activation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            ProcceedTransaction pt = new ProcceedTransaction(currentUser);
                            this.Close();
                            pt.Show();

                        }

                        string password = currentUser.Password;
                        string name = currentUser.Name;
                        string email = currentUser.Email;

                        currentUser = new UserClass(id, password, name, email, isCardActivated);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void CancelLabelClick(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
