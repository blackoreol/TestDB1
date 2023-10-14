using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TestDB1
{
    public partial class DomainForm : Form

    {
        DataManager dataManager = new DataManager();
        DatabaseManager dbManager = new DatabaseManager();
        public DomainForm()
        {
            InitializeComponent();
            dbManager.OpenConnection();
            List<string[]> data = dataManager.GetDataFromDatabase();
            foreach (string[] row in data)
            {
                dataGridView1.Rows.Add(row);
            }
        }

        public void updateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataManager.GetDataFromDatabase();
            List<string[]> data = dataManager.GetDataFromDatabase();
            foreach (string[] row in data)
            {
                dataGridView1.Rows.Add(row);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            dbManager.CloseConnection();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string update_query = "update dbo.Domains set domain_name=@domain_n,days_left=@days_l where domain_name=@domain_n";
            dbManager.OpenConnection();
            SqlCommand update_command = new SqlCommand();
            update_command.Connection = dbManager.Connection;
            update_command.CommandType = CommandType.Text;
            update_command.CommandText = update_query;
            update_command.Parameters.AddWithValue("@domain_n", textBox3.Text);
            update_command.Parameters.AddWithValue("@days_l", textBox2.Text);
            update_command.ExecuteNonQuery();
            MessageBox.Show("Record Updated Successfully");
        }

        private void tabControl1_Click(object sender, EventArgs e) // Обновление по нажатию на вкладку
        {
            if (tabControl1.SelectedTab.Text == "Список")
            {
                dataGridView1.Rows.Clear();
                List<string[]> data = dataManager.GetDataFromDatabase();

                foreach (string[] row in data)
                {
                    dataGridView1.Rows.Add(row);
                }
            }       
        }
    }
}
