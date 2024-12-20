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
    public partial class RemoveUser : Form
    {
        public RemoveUser()
        {
            InitializeComponent();
        }


        private void BackClick(object sender, EventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();
            this.Close();
            adminPanel.Show();
        }

        private void RemoveUserClick(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Atm;Integrated Security=True;" +
                        "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            SqlConnection con = new SqlConnection(ConnectionString);

            string id = textBox1.Text;
            string name = textBox2.Text;

            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Please enter a valid Id.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                con.Open();
                string query = "DELETE FROM Users WHERE Id=@id AND Name= @name ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                int rowsEffected = cmd.ExecuteNonQuery();
                if (rowsEffected > 0)
                {
                    MessageBox.Show($"User deleted succesfully with the id: {id}","Success",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("User not found with that Id or Name!", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured! " + ex);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
