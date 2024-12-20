using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Windows.Forms;
using Atm_Machine.Classes;

namespace Atm_Machine
{
    public partial class TransactionDetail : Form
    {
        private TransactionClass transaction;

        public TransactionDetail(TransactionClass transactionClass)
        {
            InitializeComponent();
            this.transaction = transactionClass;
            PopulateDetailsInGrid();
        }

        private void PopulateDetailsInGrid()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("Field", "Field");
            dataGridView1.Columns.Add("Value", "Value"); 

            dataGridView1.Rows.Add("Transaction ID", transaction.Id);
            dataGridView1.Rows.Add("User ID", transaction.UserId);
            dataGridView1.Rows.Add("Date", transaction.DateTime.ToString("g"));
            dataGridView1.Rows.Add("Amount", transaction.Amount);
            dataGridView1.Rows.Add("Type", transaction.Type);

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string folderPath = @"C:\Users\Track Computers\Desktop\Atm\Atm Machine\Transaction Data";
            System.IO.Directory.CreateDirectory(folderPath);
            string filePath = System.IO.Path.Combine(folderPath, $"Transaction_{transaction.Id}.txt");

            System.IO.File.WriteAllText(filePath, $"Transaction Details:\n\n" +
                                                  $"\t\tTransaction ID: {transaction.Id}\n" +
                                                  $"\t\tUser ID: {transaction.UserId}\n" +
                                                  $"\t\tDate: {transaction.DateTime}\n" +
                                                  $"\t\tAmount: {transaction.Amount}\n" +
                                                  $"\t\tType: {transaction.Type}");
            MessageBox.Show("Transaction details saved to file:\n" + filePath, "Print Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

