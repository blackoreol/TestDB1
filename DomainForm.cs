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
        readonly DataManager dataManager = new DataManager();
        readonly DatabaseManager dbManager = new DatabaseManager();
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

        public void UpdateToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void Button1_Click(object sender, EventArgs e)
        {
            string update_query = "update dbo.Domains set domain_name=@domain_n,days_left=@days_l where domain_name=@domain_n";
            string insert_query = "INSERT INTO dbo.Domains(domain_name,days_left) VALUES (@domain_n,@days_l)";
            dbManager.OpenConnection();
            DataChecker dataChecker = new DataChecker();
            string tableName = "dbo.Domains";
            string columnName = "domain_name";
            string valueToCheck = textBox3.Text; // Замените на нужное значение

            bool found = dataChecker.CheckValueInDatabase(tableName, columnName, valueToCheck);

            if (found)
            {
                MessageBox.Show($"Значение '{valueToCheck}' найдено в таблице {tableName}.");
                SqlCommand update_command = new SqlCommand
                {
                    Connection = dbManager.Connection,
                    CommandType = CommandType.Text,
                    CommandText = update_query
                };
                update_command.Parameters.AddWithValue("@domain_n", textBox3.Text);
                update_command.Parameters.AddWithValue("@days_l", textBox2.Text);
                update_command.ExecuteNonQuery();
                MessageBox.Show("Обновлено успешно");
            }
            else
            {
                SqlCommand insert_command = new SqlCommand
                {
                    Connection = dbManager.Connection,
                    CommandType = CommandType.Text,
                    CommandText = insert_query
                };
                insert_command.Parameters.AddWithValue("@domain_n", textBox3.Text);
                insert_command.Parameters.AddWithValue("@days_l", textBox2.Text);
                insert_command.ExecuteNonQuery();            
                MessageBox.Show($"Ошибка: Значение '{valueToCheck}' не найдено в таблице.Добавлено.");
            }
            dbManager.CloseConnection();     
        }

        private void TabControl1_Click(object sender, EventArgs e) // Обновление по нажатию на вкладку
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
