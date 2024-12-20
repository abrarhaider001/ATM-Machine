using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Atm_Machine.Classes;
using Microsoft.Data.SqlClient;

namespace Atm_Machine
{
    public partial class EnterCard : Form
    {
        private UserClass? currentUser;

        public EnterCard()
        {
            InitializeComponent();
            //richTextBox1.SelectAll();
            //richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            //richTextBox1.DeselectAll();
            currentUser = null;
        }


        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Cursor = Cursors.WaitCursor;
        //    if (!int.TryParse(richTextBox1.Text, out int enteredCardNo))
        //    {
        //        MessageBox.Show("Please enter a valid numeric card number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Atm;Integrated Security=True;" +
        //        "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        //    SqlConnection con = new SqlConnection(connectionString);

        //    try
        //    {
        //        con.Open();

        //        string query = "SELECT Id, Password, Name, Email, isCardActivated FROM Users WHERE Id = @Id";
        //        SqlCommand cmd = new SqlCommand(query, con);
        //        cmd.Parameters.AddWithValue("@Id", enteredCardNo);

        //        SqlDataReader reader = cmd.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            int id = reader.GetInt32(0);
        //            string password = reader.GetString(1);
        //            string name = reader.GetString(2);
        //            string email = reader.GetString(3);
        //            bool isCardActivated = reader.GetBoolean(4);

        //            currentUser = new UserClass(id, password, name, email, isCardActivated);

        //            EnterPin pinForm = new EnterPin(currentUser);
        //            this.Hide();
        //            pinForm.Show();
        //        }
        //        else if (enteredCardNo == 1122)
        //        {
        //            EnterPin pinForm = new EnterPin(null, true);
        //            this.Close();
        //            pinForm.Show();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Invalid Card #.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        Cursor = Cursors.Default;
        //        con.Close();
        //    }
        //}


    }
}
