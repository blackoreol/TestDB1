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


    public partial class Form1 : Form
    {
        Connectors Connector = new Connectors(); // Указываем класс Connectors
        Updater Updaters = new Updater();        // Подключаю обновление из БД
        public Form1()
        {
            InitializeComponent();   
            Connector.ConnectToDB();
            
            // Запуск соединения из класса Connectors

            string query = "SELECT * FROM dbo.Domains ORDER BY days_left";
            SqlCommand command = new SqlCommand();
            command.Connection = Connector.Connector;
            command.CommandType = CommandType.Text;
            command.CommandText = query;

            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[3]);
                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
            }
            reader.Close();
            

            foreach (string[] i in data)
                dataGridView1.Rows.Add(i);
        }

        private void updateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Connector.ConnectToDB();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Connector.DisconnectFromDB();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string update_query = "update dbo.Domains set domain_name=@domain_n,days_left=@days_l where domain_name=@domain_n";
            Connector.ConnectToDB();
            SqlCommand update_command = new SqlCommand();
            update_command.Connection = Connector.Connector;
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
                Updater upd = new Updater();

                upd.Update();

                string query = "SELECT * FROM dbo.Domains ORDER BY days_left";
                SqlCommand command = new SqlCommand
                {
                    Connection = Connector.Connector,
                    CommandType = CommandType.Text,
                    CommandText = query
                };
                SqlDataReader reader = command.ExecuteReader();
                List<string[]> data = new List<string[]>();
                while (reader.Read())
                {
                    data.Add(new string[3]);
                    data[data.Count - 1][0] = reader[0].ToString();
                    data[data.Count - 1][1] = reader[1].ToString();
                    data[data.Count - 1][2] = reader[2].ToString();
                }
                reader.Close();

                foreach (string[] i in data)


                    dataGridView1.Rows.Add(i);
            }
            else 
            {
                MessageBox.Show("hello world");
            }
        }
    }
}
